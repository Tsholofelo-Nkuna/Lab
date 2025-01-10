import { Component, EventEmitter, input, Input, Output, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
 
  contentTemplate  = input<TemplateRef<any>>();
  @Input()
  show = false;
  @Output()
  showChange = new EventEmitter<boolean>();
  @Output()
  okClick = new EventEmitter();

  onCancelClick(e: Event){
    e.stopPropagation();
    this.show=false;
    this.showChange.emit(this.show);
  }
}
