import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NewTopping } from 'src/app/interfaces';
import { ToppingService } from 'src/app/topping.service';

@Component({
  selector: 'app-add-new-topping',
  templateUrl: './add-new-topping.component.html'
})
export class AddNewToppingComponent {

  newToppingForm : FormGroup;
  newTopping : NewTopping;

  constructor(protected formBuilder : FormBuilder,
    private toppingService : ToppingService,
    private router : Router) { 
      this.newToppingForm = formBuilder.group ({
        Name : '',
        Quantity : ''
      });
      this.newToppingForm.controls["Name"].setValidators([Validators.required]);
    }
    
    public onSubmit(): void {      
      this.newToppingForm.controls['Quantity'].setValue(Number(this.newToppingForm.controls['Quantity'].value));
      this.newTopping = this.newToppingForm.value;
      this.toppingService.addTopping(this.newTopping);
      this.router.navigate(['/app-topping']);    
    }
}
