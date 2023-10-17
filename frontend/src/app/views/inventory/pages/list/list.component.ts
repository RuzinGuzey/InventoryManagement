import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { ReplaySubject, takeUntil } from 'rxjs';
import { Inventory } from 'src/app/models/inventory.model';
import { InventoriesService } from 'src/app/services/inventories.service';

@Component({
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit, OnDestroy {
  dataSet: Array<Inventory>;

  constructor(
    private inventoriesService: InventoriesService,
    private notification: NzNotificationService,
    private router: Router
  ) {}
  private destroy$: ReplaySubject<number> = new ReplaySubject(1);

  ngOnInit(): void {
    this.inventoriesService
      .get()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: Array<Inventory>) => (this.dataSet = res),
      });
  }

  edit(id: number) {
    this.router.navigate(['inventory', 'edit', id]);
  }

  deleteRow(id: number) {
    this.inventoriesService
      .delete(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: () =>
          (this.dataSet = this.dataSet.filter((d: Inventory) => d.id !== id)),
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(1);
    this.destroy$.complete();
  }
}
