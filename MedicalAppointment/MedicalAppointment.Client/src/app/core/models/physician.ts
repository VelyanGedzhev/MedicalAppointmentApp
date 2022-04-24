import { Appointment } from "./appointment";

export interface Physician {
    id: number;
    name: string;
    gender: string;
    city: string;
    address: string;
    examPrice: number;
    speciality: string;
    imageUrl: string;
    description: string;
    appointments: Appointment[];
}