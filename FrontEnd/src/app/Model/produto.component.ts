import { Component, OnInit } from '@angular/core';
import { Produto } from '../view/produto.modelo';
import { ProdutoService} from '../Services/produto.service'

@Component({
  selector: 'app-produto',
  templateUrl: '../view/produto.component.html',
  styleUrls: ['../view/produto.component.css']
})
export class ProdutoComponent implements OnInit {

  titulo : string = 'Cadastro de Produtos'
  produto : Produto = new Produto();
  produtos : Produto[] = [];

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.getProdutos();
  }

  getProdutos(): void {
    this.produtoService.getProdutos()
    .subscribe(response => {
      if (response.Status == 0){
        this.produtos = response.Categoria;
      }
    });
  }

  cadastrar() : void {
    if(this.produto.Id === undefined){
      this.produtoService.addProduto(this.produto)
      .subscribe(response => {
        if(response.Status == 0){
          this.getProdutos();  
        }
        else{
          console.log(response.Detalhes);
        }      
      });
    }
    else{
      this.produtoService.updateProduto(this.produto)
      .subscribe(response => {
        if(response.Status){
          this.getProdutos();
        }
        else{
          console.log(response.Detalhes);
        }
      });
    }
    this.produto = new Produto();
  }

  remover(id) : void {
    this.produtoService.deleteProduto(id)
    .subscribe(response => {
      if(response.Status == 0){
        this.getProdutos();
      }
      else{
        console.log(response.Detalhes)
      }
    });
  }

  editar(i) : void {
    this.produto.Id = this.produtos[i].Id;
    this.produto.Marca = this.produtos[i].Marca;
    this.produto.Modelo = this.produtos[i].Modelo;
    this.produto.Motor = this.produtos[i].Motor;
    this.produto.Cor = this.produtos[i].Cor;
    this.produto.Valor = this.produtos[i].Valor;
  }


}
