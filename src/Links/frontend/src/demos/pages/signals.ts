import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-demos-signals',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `<div>
    <span class="text-2xl p-8">{{ strokes }}</span>
    <span class="text-2xl p-8">{{ strokes }}</span>
    <span class="text-2xl p-8">{{ strokes }}</span>
    <span class="text-2xl p-8">{{ strokes }}</span>
    <button (click)="takeASwing()" class="btn btn-success">Take A Shot</button>

    <span class="text-2xl p-8">{{ strokes }}</span>
    <span class="text-2xl p-8">{{ strokes }}</span>
  </div>`,
  styles: ``,
})
export class Signals {
  takeASwing() {
    this.strokes++;
  }

  strokes = 0;
}
