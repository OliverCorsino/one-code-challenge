import { ContactInformation } from './contact-information';
export interface User {
  id: number;
  identificationNumber: string;
  name: string;
  lastName: string;
  dateOfBirth: Date;
  educationLevelId: number;
  registrationDate: Date;
  roleId: number;
  contactInformations: ContactInformation[];
}
