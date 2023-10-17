import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleInventoryListComponent } from './vehicle-inventory-list.component';

describe('VehicleInventoryListComponent', () => {
  let component: VehicleInventoryListComponent;
  let fixture: ComponentFixture<VehicleInventoryListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VehicleInventoryListComponent]
    });
    fixture = TestBed.createComponent(VehicleInventoryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
