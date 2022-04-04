export interface CharacterDto {
  id: number;
  name: string;
  status: string;
  species: string;
  type: string;
  gender: string;
  origin:object;
  location:object;
  image:string;
  episode:string[];
  url:string;
  created:string;
}
export interface AllCharactersDto {
  info:object;
  results:object[];
}

