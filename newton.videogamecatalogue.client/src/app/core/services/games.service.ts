import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Game } from "../models/game";

@Injectable({
    providedIn: "root"
})
export class GamesService {
    constructor(
        private http: HttpClient,
        @Inject('API_URL') private apiUrl: string
    ) { }

    getAll(): Observable<Game[]> {
        return this.http.get<Game[]>(this.apiUrl);
    }

    get(id: number): Observable<Game> {
        return this.http.get<Game>(`${this.apiUrl}/${id}`);
    }

    create(game: Game): Observable<Game> {
        return this.http.post<Game>(this.apiUrl, game);
    }

    update(id: number, game: Game): Observable<Game> {
        return this.http.put<Game>(`${this.apiUrl}/${id}`, game);
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}