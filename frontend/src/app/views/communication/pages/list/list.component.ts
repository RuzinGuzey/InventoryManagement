import { Component, OnDestroy, OnInit } from '@angular/core';
import { ReplaySubject, takeUntil } from 'rxjs';
import { Communication } from 'src/app/models/communication.model';
import { CommunicationsService } from 'src/app/services/communications.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit, OnDestroy {
  dataSet: any;

  constructor(private communicationsService: CommunicationsService) {}
  private destroy$: ReplaySubject<number> = new ReplaySubject(1);

  ngOnInit(): void {
    this.communicationsService
      .get()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: Array<Communication>) => (this.dataSet = res),
      });
  }

  edit(id: number) {}

  delete(id: number) {}

  ngOnDestroy(): void {
    this.destroy$.next(1);
    this.destroy$.complete();
  }
}
