import { Empresa } from './../models/Empresa';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmpresaService } from '../services/empresa.service';


@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})
export class EmpresasComponent implements OnInit {

  empresas: Empresa[];
  empresa: Empresa;

  constructor(private http: HttpClient, private empresaService: EmpresaService) { }

  ngOnInit() {

   this.getempresas();

  }

  getempresas() {
    this.empresaService.getAllEmpresas().subscribe(
      (_Empresas: Empresa []) => {
        this.empresas = _Empresas;
        console.log(_Empresas);
        console.log('separador');
        console.log(this.empresas);
      }, error => {
      console.log(`Erro ao tentar Carregar eventos: ${error}`);

      });
  }



}
