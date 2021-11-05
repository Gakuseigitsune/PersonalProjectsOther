import { Component, Input } from '@angular/core';
import { Character } from '../character';

@Component({
    selector: 'app-character-detail',
    templateUrl: './character-detail.component.html',
    styleUrls: ['./character-detail.component.css']
})
/** characterDetail component*/
export class CharacterDetailComponent {

  @Input() chara_Selected: Character = { cid: 0, name: 'N/A', species: 'N/A', char_class: 'N/A' };

  expandedView: boolean = false;

    /** characterDetail ctor */
  constructor() { }

  expandDetail(isExpanded: boolean) {
    this.expandedView = isExpanded;
    console.log(`isExpanded: ${this.expandedView}`);
  }

    
  

}
