import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ListEntry } from '../../models/list-entry';

@Component({
  selector: 'app-unordered-list',
  templateUrl: './unordered-list.component.html',
  styleUrls: ['./unordered-list.component.scss']
})
export class UnorderedListComponent implements OnInit {
  @Output()
  entrySelected = new EventEmitter<PointerEvent>();
  @Input()
  listEntries: ListEntry[];
  @Input()
  selectedEntryId: number;

  constructor() { }

  ngOnInit(): void {
  }

  onEntrySelected(event: any) {
    this.entrySelected.emit(event);
  }

}
