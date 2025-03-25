import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';  // ✅ Import CommonModule for *ngFor

@Component({
  selector: 'app-contact',
  standalone: true, // ✅ If using Standalone Component, add this
  imports: [CommonModule], // ✅ Required for *ngFor
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent { }
