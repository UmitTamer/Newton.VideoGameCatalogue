import { Component, inject, input, OnInit, signal } from '@angular/core';
import { GameForm } from '../../components/game-form/game-form';
import { GamesService } from '../../core/services/games.service';
import { Router, } from '@angular/router';
import { Game } from '../../core/models/game';

@Component({
  selector: 'app-game-edit',
  standalone: true,
  imports: [GameForm],
  templateUrl: './game-edit.html'
})
export class GameEdit implements OnInit {
  id = input.required<number>();
  gamesService = inject(GamesService);
  router = inject(Router);

  // Signal to hold the game being edited. Null until loaded.
  game = signal<Game | null>(null);

  ngOnInit(): void {
    this.gamesService.get(this.id()).subscribe({
      next: g => this.game.set(g),
      error: err => {
        console.error('Error fetching game:', err);
        this.router.navigate(['/']); // Navigate back to list on error
      }
    });
  }

  onSubmit(updatedGame: Game) {
    this.gamesService.update(this.id(), updatedGame).subscribe({
      next: () => this.router.navigate(['/']),
      error: err => console.error('Error updating game:', err)
    });
  }
}
