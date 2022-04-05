import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-podaci',
  templateUrl: './podaci.component.html',
  styleUrls: ['./podaci.component.scss']
})
export class PodaciComponent implements OnInit {

  podaci: any = [];
  loading: boolean = false;
  error: boolean = false;
  success: boolean = false;
  message: string = "";

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

  getPodaci(){
    this.podaci = [];
    this.loading = true;    
    this.apiService.getPodaci().subscribe(data => {
      this.podaci = data;
      this.loading = false;
      this.error = false;
    }, error => {
      console.log(error);
      this.loading = false;
      this.error = true;
      this.message = "Dogodila se pogreška, ne mogu dohvatiti podatke!"
    })
  }

  savePodaci(){   
    this.apiService.postPodaci(this.podaci).subscribe(data => {
      if(data.body.length > 0){
        this.saveFailed("Dogodila se pogreška, ne mogu spremiti podatke!")
      }
      else{
        this.error = false;
        this.success = true;
        this.message = "Podaci su uspješno pohranjeni!"
      }
    },error => {
      console.log(error);
      this.saveFailed("Dogodila se pogreška, ne mogu spremiti podatke!")
    })
  }

  saveFailed(message:string) {
    this.loading = false;
      this.error = true;
      this.success = false;
      this.message = message;
  }
}
