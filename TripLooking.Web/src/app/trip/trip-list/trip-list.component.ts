import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Trip } from '../models/trip';

@Component({
  selector: 'app-trip-list',
  templateUrl: './trip-list.component.html',
  styleUrls: ['./trip-list.component.scss'],
})
export class TripListComponent implements OnInit {
  public tripList: Trip[];

  constructor(private router: Router) {}

  public ngOnInit(): void {
    this.tripList = [
      {
        id: '1',
        name: 'Excursie in Delta',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '2',
        name: 'Excursie la Marea Neagra',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '3',
        name: 'Excursie in Bucegi',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },
      {
        id: '1',
        name: 'Excursie in Delta',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '2',
        name: 'Excursie la Marea Neagra',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '3',
        name: 'Excursie in Bucegi',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },
      {
        id: '1',
        name: 'Excursie in Delta',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '2',
        name: 'Excursie la Marea Neagra',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },

      {
        id: '3',
        name: 'Excursie in Bucegi',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../assets/images/travel_logo.png',
        isPrivate: false,
      },
    ];
  }

  goToTrip(id: string): void {
    console.log(id);
    this.router.navigate(['/trip/details']);
  }
}
