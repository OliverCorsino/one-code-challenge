import { ContactInformation } from './contact-information';
export interface User {
  id: string;
  identificationNumber: string;
  name: string;
  lastName: string;
  dateOfBirth: Date;
  educationLevel: string;
  registrationDate: Date;
  role: string;
  contactInformations: ContactInformation[];
}
