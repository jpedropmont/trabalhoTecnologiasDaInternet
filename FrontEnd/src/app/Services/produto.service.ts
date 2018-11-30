import { Injectable } from '@angular/core';
import { Produto } from '../view/produto.modelo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of} from 'rxjs';


@Injectable({ providedIn: 'root'})
export class ProdutoService {

	private url = 'http://localhost:50767/api/produto';
	private httpOptions = {
	headers: new HttpHeaders({ 'Content-Type':'application/xwww-form-urlencoded'})};
	
	constructor(private http: HttpClient) { }	

	getProdutos(): Observable<any> {
		return this.http.get<any>(this.url, this.httpOptions);
	}

	getproduto(id: number): Observable<any>{
		let url_ = this.url + '/' + id;
		return this.http.get<any>(url_, this.httpOptions);
	}

	addProduto(produto: Produto): Observable<any> {
		let u = new URLSearchParams();
		u.set('Marca', produto.Marca.toString());
		u.set('Modelo', produto.Modelo.toString());
		u.set('Motor', produto.Motor.toString());
		u.set('Cor', produto.Cor.toString());
		u.set('Valor', produto.Valor.toString());
		return this.http.post<any>(this.url, u.toString(), this.httpOptions);
	}

	updateProduto(produto: Produto): Observable<any> {
		let u = new URLSearchParams();
		u.set('Id', produto.Id.toString());
		u.set('Marca', produto.Marca.toString());
		u.set('Modelo', produto.Modelo.toString());
		u.set('Motor', produto.Motor.toString());
		u.set('Cor', produto.Cor.toString());
		u.set('Valor', produto.Valor.toString());
		let url_ = this.url + '/' + produto.Id;
		return this.http.put<any>(url_, u.toString(), this.httpOptions);
	}

	deleteProduto(id: Number): Observable<any> {
		let url_ = this.url + '/' + id;
		return this.http.delete<any>(url_, this.httpOptions);
	}
}



