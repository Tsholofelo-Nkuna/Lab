import { Component, EventEmitter, Input, Output, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @Input({required: true})
  contentTemplate : TemplateRef<any> | null = null;
  @Input()
  show = false;
  @Output()
  showChange = new EventEmitter<boolean>();

  onCancelClick(e: Event){
    e.stopPropagation();
    this.show=false;
    this.showChange.emit(this.show);
  }
}
