import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empresa } from '../models/Empresa';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

baseURL = 'http://localhost:4300/api/empresa';

constructor(private http: HttpClient) { }

getAllEmpresas(): Observable<Empresa[]> {
  return this.http.get<Empresa[]>(this.baseURL);
}

getEmpresaById(id: number): Observable<Empresa> {
  return this.http.get<Empresa>(`${this.baseURL}/${id}`);
}

postUpload(file: File, name: string) {
  const fileToUplaod = <File>file[0];
  const formData = new FormData();
  formData.append('file', fileToUplaod, name);

  return this.http.post(`${this.baseURL}/upload`, formData);
}

postEvento(empresa: Empresa) {
  return this.http.post(this.baseURL, empresa);
}

putEvento(empresa: Empresa) {
  return this.http.put(`${this.baseURL}/${empresa.empresaId}`, empresa);
}

deleteEmpresa(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}


}
