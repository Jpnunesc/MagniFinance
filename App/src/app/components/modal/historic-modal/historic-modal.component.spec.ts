import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricModalComponent } from './historic-modal.component';

describe('HistoricModalComponent', () => {
  let component: HistoricModalComponent;
  let fixture: ComponentFixture<HistoricModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
