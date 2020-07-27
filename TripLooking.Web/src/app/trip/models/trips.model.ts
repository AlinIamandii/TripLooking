import { TripModel } from './trip.model';

export type TripsModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: TripModel[];
};
