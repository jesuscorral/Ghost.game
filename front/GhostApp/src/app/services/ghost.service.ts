import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GhostData } from '../ghost-game/model/ghost.model';

@Injectable()
export class GhostService {

  formData: GhostData;
  readonly rootURL = 'https://localhost:44351/api/Ghost/checkWord';

  constructor(private http: HttpClient) {
   }

   checkWord(request: GhostData) {
    return this.http.post(this.rootURL, request)
    .subscribe(data  => {
      console.log('POST Request is successful',
      data);
      },
      error  => {
      console.log('Error', error);
      }
      );
   }
}
