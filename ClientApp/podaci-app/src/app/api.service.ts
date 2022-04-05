import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class ApiService {
    constructor(private httpClient: HttpClient) { }
    getPodaci(){
        return this.httpClient.get(environment.webApi);
    }
    postPodaci(data){
        return this.httpClient.post(environment.webApi, data,{observe: 'response', responseType: 'text'});
    }
}