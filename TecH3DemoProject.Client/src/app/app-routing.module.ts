import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { AuthorsComponent } from './authors/authors.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
   { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
   { path: 'dashboard', component: DashboardComponent },
   { path: 'author/:id', component: AuthorDetailComponent },
   { path: 'authors', component: AuthorsComponent }
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule { }
