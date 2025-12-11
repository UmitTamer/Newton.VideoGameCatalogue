import { Component, OnInit, signal, effect, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GamesService } from '../../core/services/games.service';
import { Game } from '../../core/models/game';
import { catchError } from 'rxjs';

@Component({
  selector: 'app-games-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './games-list.html'
})
export class GamesList implements OnInit {
  games = signal<Game[]>([]);
  gamesService = inject(GamesService);

  ngOnInit(): void {
    this.gamesService.getAll()
      .pipe(
        catchError(err => {
          console.error('Error fetching games:', err);
          throw err;
        })
      )
      .subscribe(data => this.games.set(data));
  }

  deleteGame(id: number) {
    if (!confirm('Are you sure you want to delete this game?')) {
      return;
    }

    this.gamesService.delete(id).subscribe({
      next: () => {
        // Update the signal to remove the deleted game
        this.games.update(gamesList => gamesList.filter(game => game.id !== id));
      },
      error: err => console.error('Error deleting game:', err)
    });
  }
}
