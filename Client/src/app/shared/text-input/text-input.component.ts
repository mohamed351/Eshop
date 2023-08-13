import { Component, OnInit ,Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements ControlValueAccessor , OnInit {
 @Input() type = "text";
 @Input() label = "";
  constructor(@Self() public controlDir:NgControl) {

    controlDir.valueAccessor = this;

  }
  writeValue(obj: any): void {

  }
  registerOnChange(fn: any): void {

  }
  registerOnTouched(fn: any): void {

  }
  setDisabledState?(isDisabled: boolean): void {

  }


  ngOnInit(): void {
  }
  get control():FormControl<any>{
    return this.controlDir.control as FormControl<any>;


  }
}
