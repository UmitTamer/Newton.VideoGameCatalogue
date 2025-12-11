import { Component, inject } from '@angular/core';
import { GamesService } from '../../core/services/games.service';
import { Router } from '@angular/router';
import { Game } from '../../core/models/game';
import { GameForm } from '../../components/game-form/game-form';

@Component({
  selector: 'app-game-create',
  standalone: true,
  imports: [GameForm],
  templateUrl: './game-create.html'
})
export class GameCreate {
  gameService = inject(GamesService);
  router = inject(Router);

  onSubmit(game: Game) {
    this.gameService.create(game).subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => console.error('Error creating game:', err)
    });
  }
}
