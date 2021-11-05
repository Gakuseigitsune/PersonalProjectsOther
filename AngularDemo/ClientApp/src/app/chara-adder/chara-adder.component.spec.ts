/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CharaAdderComponent } from './chara-adder.component';

let component: CharaAdderComponent;
let fixture: ComponentFixture<CharaAdderComponent>;

describe('CharaAdder component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CharaAdderComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CharaAdderComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});