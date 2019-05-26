import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GhostGameComponent } from './ghost-game.component';

describe('GhostGameComponent', () => {
  let component: GhostGameComponent;
  let fixture: ComponentFixture<GhostGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GhostGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GhostGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
