import { Component, OnInit } from '@angular/core';
import { Categoria } from '../view/categoria.modelo'
import { CategoriaService } from '../Services/categoria.service'

@Component({
  selector: 'app-categoria',
  templateUrl: '../view/categoria.component.html',
  styleUrls: ['../view/categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  titulo : string = 'Cadastro de Categorias'
  categoria : Categoria = new Categoria();
  categorias : Categoria[] = [];

  constructor(private categoriaService: CategoriaService) { }

  ngOnInit() {
    this.getCategorias();
  }

  getCategorias(): void {
    this.categoriaService.getCategorias()
    .subscribe(response => {
      if (response.Status == 0){
        this.categorias = response.Categorias;
      }
    });
  }

  cadastrar() : void {
    if(this.categoria.Id === undefined){
      this.categoriaService.addCategoria(this.categoria)
      .subscribe(response => {
        if(response.Status == 0){
          this.getCategorias();  
        }
        else{
          console.log(response.Detalhes);
        }      
      });
    }
    else{
      this.categoriaService.updateCategoria(this.categoria)
      .subscribe(response => {
        if(response.Status){
          this.getCategorias();
        }
        else{
          console.log(response.Detalhes);
        }
      });
    }
    this.categoria = new Categoria();
  }

  remover(id) : void {
    this.categoriaService.deleteCategoria(id)
    .subscribe(response => {
      if(response.Status == 0){
        this.getCategorias();
      }
      else{
        console.log(response.Detalhes)
      }
    });
  }

  editar(i) : void {
    this.categoria.Nome = this.categorias[i].Nome;
    this.categoria.Id = this.categorias[i].Id;
  }

}