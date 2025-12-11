import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'games',
        pathMatch: 'full'
    },
    {
        path: 'games',
        loadComponent: () => import('./pages/games-list/games-list').then(m => m.GamesList)
    },
    {
        path: 'games/create',
        loadComponent: () => import('./pages/game-create/game-create').then(m => m.GameCreate)
    },
    {
        path: 'games/edit/:id',
        loadComponent: () => import('./pages/game-edit/game-edit').then(m => m.GameEdit)
    },
    {
        path: '**',
        redirectTo: 'games'
    }
];
