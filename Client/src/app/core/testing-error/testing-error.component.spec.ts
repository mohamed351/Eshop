import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestingErrorComponent } from './testing-error.component';

describe('TestingErrorComponent', () => {
  let component: TestingErrorComponent;
  let fixture: ComponentFixture<TestingErrorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestingErrorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestingErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
