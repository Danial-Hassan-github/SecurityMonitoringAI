import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Dashboard } from './features/dashboard/dashboard';
import { Sidebar } from './layout/sidebar/sidebar';
import { Topbar } from './layout/topbar/topbar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Dashboard, Sidebar, Topbar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('SecurityMonitoring.Client');
}
