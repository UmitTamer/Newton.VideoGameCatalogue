import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Game } from '../../core/models/game';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './game-form.html'
})
export class GameForm {
  @Input() header = '';
  @Input() buttonText = '';

  model: Game = {
    id: 0,
    title: '',
    genre: '',
    releaseYear: 0,
    rating: 0
  };

  @Input() set game(value: Game | null | undefined) {
    if (value) {
      this.model = { ...value };
    }
  }

  @Output() submitForm = new EventEmitter<Game>();

  onSubmit(form: NgForm) {
    if (form.invalid) return;
    this.submitForm.emit({ ...this.model });
  }
}