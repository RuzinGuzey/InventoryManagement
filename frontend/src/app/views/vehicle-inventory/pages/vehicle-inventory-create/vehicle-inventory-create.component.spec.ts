import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleInventoryCreateComponent } from './vehicle-inventory-create.component';

describe('VehicleInventoryCreateComponent', () => {
  let component: VehicleInventoryCreateComponent;
  let fixture: ComponentFixture<VehicleInventoryCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleInventoryCreateComponent]
    });
    fixture = TestBed.createComponent(VehicleInventoryCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
