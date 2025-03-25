import { Routes } from '@angular/router';
import { ContactComponent } from './components/contact/contact.component';  // ✅ Ensure correct path
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: 'contact', pathMatch: 'full' },
  { path: 'contact', component: ContactComponent , canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'contact' }
];
