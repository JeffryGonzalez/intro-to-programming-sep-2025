import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
@Component({
  selector: 'app-links-add',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="addLink()">
      <fieldset class="fieldset">
        <legend class="fieldset-legend">The Title of the Link</legend>
        <input
          formControlName="title"
          type="text"
          class="input"
          placeholder=""
        />
        <p class="label">required</p>
        @let titleInput = form.controls.title;
        @if (titleInput.errors && (titleInput.touched || titleInput.dirty)) {
          <div class="alert alert-error">
            <p>This field has some errors!</p>
            @if (titleInput.hasError('required')) {
              <p>This is required</p>
            }
            @if (titleInput.hasError('maxlength')) {
              <p>This is too darned long.</p>
            }
          </div>
        }
      </fieldset>
      <fieldset class="fieldset">
        <legend class="fieldset-legend">Description of the Link</legend>
        <textarea
          formControlName="description"
          type="text"
          class="input"
          placeholder=""
        ></textarea>
        <p class="label">required</p>
      </fieldset>
      <fieldset class="fieldset">
        <legend class="fieldset-legend">The Link</legend>
        <input formControlName="href" type="url" class="input" placeholder="" />
        <p class="label">required</p>
      </fieldset>
      <button class="btn btn-primary" type="submit">Add This Link</button>
    </form>
  `,
  styles: ``,
})
export class Add {
  form = new FormGroup({
    title: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.maxLength(100)],
    }),
    description: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
    href: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required],
    }),
  });

  async addLink() {
    if (this.form.valid) {
      await fetch('http://localhost:1337/links', {
        method: 'POST',
        body: JSON.stringify(this.form.value),
        headers: {
          'Content-Type': 'application/json',
        },
      });
    } else {
      console.warn('The form is not valid - whatcha going to do?');
    }
  }
}

//
