import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule} from '@angular/common/http';

import { InicioComponent } from './model/inicio.component';
import { RaizComponent } from './model/raiz.component';
import { ProdutoComponent } from './model/produto.component';
import { CategoriaComponent } from './model/categoria.component';
import { VisualizacaoComponent } from './model/visualizacao.component';


const appRouter: Routes = [
  
  { path: '', component: InicioComponent},
  { path: 'categoria', component: CategoriaComponent},
  { path: 'produto', component: ProdutoComponent},
  { path: 'visualizacao', component: VisualizacaoComponent}

];


@NgModule({
  declarations: [
    InicioComponent,
    RaizComponent,
    ProdutoComponent,
    CategoriaComponent,
    VisualizacaoComponent
  ],
  imports: [
    RouterModule.forRoot (
      appRouter , { enableTracing: true }
    ),
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [RaizComponent]
})

export class AppModule { }
