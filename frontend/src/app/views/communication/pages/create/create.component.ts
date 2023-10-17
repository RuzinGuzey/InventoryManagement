import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ReplaySubject, takeUntil } from 'rxjs';
import { Communication } from 'src/app/models/communication.model';
import { CommunicationsService } from 'src/app/services/communications.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit, OnDestroy {
  dataSet: any;
  form: FormGroup;
  inventoryGroups: Array<any> = [];

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

  submit() {}

  edit(id: number) {}

  delete(id: number) {}

  ngOnDestroy(): void {
    this.destroy$.next(1);
    this.destroy$.complete();
  }
}
