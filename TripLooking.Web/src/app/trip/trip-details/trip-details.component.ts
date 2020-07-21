import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.scss']
})
export class TripDetailsComponent implements OnInit {
  fileToUpload: any;
  imageUrl: any;

  name: string;
  description: string;
  isPrivate: boolean;
  isAdmin: boolean;
  isEditing: boolean;
  photos: Blob[] = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
    if (this.router.url === '/create-trip') {
      this.isEditing = true;
    } else {
      this.name = "My first trip";
      this.description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
      this.isEditing = false;
    }
    this.isPrivate = true;
    this.isAdmin = true;
  }

  startUpdating() {
    this.isEditing = true;
  }

  save() {
    this.photos.push(this.imageUrl);
    this.imageUrl = null;
    this.isEditing = false;
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

}
