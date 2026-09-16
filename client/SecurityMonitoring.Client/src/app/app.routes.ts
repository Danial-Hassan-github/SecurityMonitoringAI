import { Routes } from '@angular/router';

import { Dashboard } from './features/dashboard/dashboard';
import { SecurityEvents } from './features/security-events/security-events';
import { Incidents } from './features/incidents/incidents';
import { Threats } from './features/threats/threats';
import { AiAnalysis } from './features/ai-analysis/ai-analysis';
import { Settings } from './features/settings/settings';

export const routes: Routes = [

  {
    path: '',
    component: Dashboard
  },

  {
    path: 'security-events',
    component: SecurityEvents
  },

  {
    path: 'incidents',
    component: Incidents
  },

  {
    path: 'threats',
    component: Threats
  },

  {
    path: 'ai-analysis',
    component: AiAnalysis
  },

  {
    path: 'settings',
    component: Settings
  }

];