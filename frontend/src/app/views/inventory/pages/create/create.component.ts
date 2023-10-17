import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ReplaySubject, takeUntil } from 'rxjs';
import {
  CreateInventoryRequest,
  Inventory,
  UpdateInventoryRequest,
} from 'src/app/models/inventory.model';
import { InventoriesService } from 'src/app/services/inventories.service';
import { InventoryGroup } from '../../../../models/inventory-group.model';
import { InventoryGroupsService } from '../../../../services/inventory-groups.service';

@Component({
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit, OnDestroy {
  private destroy$: ReplaySubject<number> = new ReplaySubject(1);

  inventoryGroups: Array<InventoryGroup> = [];
  form: FormGroup;
  inventoryId?: number;

  constructor(
    private inventoryGroupsService: InventoryGroupsService,
    private inventoriesService: InventoriesService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.inventoryId = this.activatedRoute.snapshot.paramMap.has('id')
      ? parseInt(this.activatedRoute.snapshot.paramMap.get('id'))
      : null;
    this.form = new FormGroup({
      marka: new FormControl('', Validators.required),
      model: new FormControl('', Validators.required),
      seriNo: new FormControl('', Validators.required),
      inventoryGroupId: new FormControl(null, Validators.required),
      entryDate: new FormControl(null, Validators.required),
      guaranteeStart: new FormControl(null),
      guaranteeEnd: new FormControl(null),
      price: new FormControl(null),
      whereAbout: new FormControl('', Validators.required),
    });

    inventoryGroupsService
      .get()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: Array<InventoryGroup>) => (this.inventoryGroups = res),
      });

    if (this.inventoryId) {
      inventoriesService
        .getById(this.inventoryId)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (res: Inventory) => this.setFormValue(res),
        });
    }
  }

  ngOnInit(): void {}

  setFormValue(inventory: Inventory) {
    this.form.patchValue(inventory);
  }

  submit() {
    if (!this.form.valid) {
      Object.values(this.form.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
      return;
    }

    if (this.inventoryId) {
      this.update();
    } else {
      this.create();
    }
  }

  update() {
    const request: UpdateInventoryRequest = this.form.value;
    request.id = this.inventoryId;
    this.inventoriesService
      .update(this.inventoryId, request)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () => {
          this.router.navigate(['inventory']);
        },
      });
  }

  create() {
    const request: CreateInventoryRequest = this.form.value;
    this.inventoriesService
      .create(request)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: number) => {
          this.router.navigate(['inventory']);
        },
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(1);
    this.destroy$.complete();
  }
}
