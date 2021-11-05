import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Character } from '../character';
import { HttpClient } from '@angular/common/http';



@Component({
    selector: 'app-chara-adder',
    templateUrl: './chara-adder.component.html',
    styleUrls: ['./chara-adder.component.css']
})
/** CharaAdder component*/
export class CharaAdderComponent {

  errors: string[] = [];
  hasError: boolean = false;

  newChara: Character = {

    cid: 0, name: '', species: '', char_class: ''

  };

  @Output() newCharaAdded = new EventEmitter<Character>();
  //@Output() error = new EventEmitter<string>();


  /*
  @Input() newName = '';
  @Input() species = '';
  @Input() class = '';*/


    /** CharaAdder ctor */
  constructor(private http: HttpClient) {

  }

  checkNull(): boolean {
    
    console.log(`name: ${!!this.newChara.name}`);
    console.log(`species: ${!!this.newChara.species}`);
    console.log(`class: ${!!this.newChara.char_class}`);
    console.log(`newCharacter: ${!!this.newChara.name && !!this.newChara.species && !!this.newChara.char_class}`);
   

    return (!!this.newChara.name && !!this.newChara.species && !!this.newChara.char_class);

  }

  addChar(): boolean {

    if (!this.checkNull()) {

      //this.error.emit("please fill in all fields before submitting!");

      console.log('error!');
      if (!this.hasError) this.errors.push("please fill in all fields before submitting!");
      this.hasError = true;
      return false;

    }

    this.hasError = false;
    this.errors.splice(0);

    this.http.post<Character>('/api/character', this.newChara).subscribe(

      (result) => {

        console.log(`Character '${this.newChara.name}' added!`)
        this.newCharaAdded.emit(this.newChara);

        this.newChara = {
          cid: 0, name: '', species: '', char_class: ''
        }

      }

    );
    return true;
  }





}
