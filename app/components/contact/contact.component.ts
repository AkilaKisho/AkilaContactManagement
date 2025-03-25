
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ElementRef, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  imports :[FormsModule],
  standalone: true,
  templateUrl: './contact.component.html', 
  styleUrl: './contact.component.scss' 
})
export class ContactComponent implements OnInit {
  @ViewChild('contactModal') contactModal!: ElementRef;

  contactList :any[]=[];
  contactObj: any = {
    "Id": 0,
    "firstName": '',
    "lastName": "",
    "email": "",
    "PhoneNumber": "",
    "address": "",
    "city": "",
    "state": "",
    "country": "",
    "postalCode": ""
  };
 http=inject(HttpClient);
 ngOnInit(): void {
   this.getAllEmployees();
 }
  openModal() {
    if (this.contactModal) {
      this.contactModal.nativeElement.style.display = 'block';
      this.contactModal.nativeElement.classList.add('show');
    }
  }

  closeModal() {
    if (this.contactModal) {
      this.contactModal.nativeElement.style.display = 'none';
    this.contactModal.nativeElement.classList.remove('show');
    }
  }

  getAllEmployees() {
    this.http.get("http://localhost:5294/api/Contact").subscribe((res: any) => {
      this.contactList = res;
    });
  }

  saveEmployee() {
    this.http.post("http://localhost:5294/api/Contact", this.contactObj).subscribe((res: any) => {
      this.contactList.push(res); 
      this.closeModal();
    });
  }
  deleteEmployee(data: any) {
    const isDelete = confirm("Are you sure you want to delete?");
    if (!isDelete) return;  
  
    this.http.delete(`http://localhost:5294/api/Contact/${data.id}`).subscribe({
      next: () => {
        this.contactList = this.contactList.filter(contact => contact.id !== data.id);
        alert("Employee deleted successfully!"); 
        
      },
      error: (error) => {
        console.error("Error deleting employee:", error);
        alert("Failed to delete employee!"); 
        
      }
    });
  }
  
  editEmployee(data: any) {
    this.contactObj = { ...data }; 
    this.openModal();
  }
  
  updateEmployee() {
    if (!this.contactObj.id) {
      alert("Error: Missing Employee ID!");
      return;
    }
  
    this.http.put(`http://localhost:5294/api/Contact/${this.contactObj.id}`, this.contactObj)
      .subscribe({
        next: () => {
          alert("Employee updated successfully!");
          this.getAllEmployees(); 
          this.closeModal();   
        },
        error: (error) => {
          console.error("Error updating employee:", error);
          alert("Failed to update employee!");
        }
      });
  }
  
}
