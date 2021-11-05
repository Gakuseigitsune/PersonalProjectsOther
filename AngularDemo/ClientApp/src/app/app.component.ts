import { Component } from '@angular/core';
import { Character } from './character';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  allChars: Character[] = [];
  newName = '';
  newSpecies = '';
  newClass = '';

  constructor(private http: HttpClient) {

    this.getChars()

  }



  getChars() {

    this.http.get<Character[]>('/api/character').subscribe(

      (result: Character[]) => {

        this.allChars = result;
        console.log(`loaded ${result.length} from DB: ${result}`);
        console.log(`${this.allChars}`);
      } 

    );

  }

  addChar() {

    let newChar = {

      name: this.newName,
      species: this.newSpecies,
      char_class: this.newClass


    }

    this.http.post<Character>('/api/character', newChar).subscribe(

      (result) => {

        this.newName = '';
        this.newSpecies = '';
        this.newClass = '';
        this.getChars();

      }

    )



    console.log(`Character ${this.newName} added!`)

  }

  /*
  showError(error: string) {

    this.hasError = true
    this.errors.push(error)

  }*/




}
