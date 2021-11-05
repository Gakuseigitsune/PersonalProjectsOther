/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CharaVisualRefComponent } from './chara-visual-ref.component';

let component: CharaVisualRefComponent;
let fixture: ComponentFixture<CharaVisualRefComponent>;

describe('charaVisualRef component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CharaVisualRefComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CharaVisualRefComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});