/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CharacterDetailComponent } from './character-detail.component';

let component: CharacterDetailComponent;
let fixture: ComponentFixture<CharacterDetailComponent>;

describe('characterDetail component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CharacterDetailComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CharacterDetailComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});