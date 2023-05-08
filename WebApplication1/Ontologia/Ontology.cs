using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VDS.RDF.Query;

namespace WebApplication1.Ontologia
{   
    public class Ontology
    {
        
        private static string baseURL = @"http://localhost:3030/Salud/sparql";
     
        public Ontology()
        {
        }
        string Prefix = @"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                             PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                             PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                             PREFIX data: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#>";

        public DataTable ListaPaciente() {
            string query = Prefix + @"Select distinct  ?paciente         
                            Where {
                              ?medico data:atiende ?paciente.}";


            return excuteQuery(query);
        }
        public DataTable ListaMedico()
        {
            string query = Prefix + @"Select distinct  ?medico         
                            Where {
                              ?medico data:atiende ?paciente.}";


            return excuteQuery(query);
        }
        public DataTable ListaIPS()
        {
            string query = Prefix + @"Select distinct  ?ips         
                            Where {
                            ?medico data:adscrito ?ips.}";


            return excuteQuery(query);
        }


        public DataTable Enfermedad(string enfermedad) {
            string query = @"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                             PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                             PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                             PREFIX data: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#>

                             select ?paciente ?medicamento 
                             where {?medicamento data:controla data:"+enfermedad+ ". ?paciente data:tiene data:" + enfermedad +". }";
            return excuteQuery(query);
        }

        public DataTable Paciente(string paciente)
        {
        string query = @"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                         PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                         PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                         PREFIX data: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#>
                         
                    SELECT  ?enfermedad ?medicamento ?medico
                    where {?enfermedad data:afecta data:" + paciente + ". ?enfermedad data:controladopor ?medicamento. ?medico data:atiende data:"+paciente+".}";
            return excuteQuery(query);
        }
        public DataTable IPS(string ips)
        {
            string query = @"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                            PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                            PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                            PREFIX data: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#>
                            SELECT ?paciente ?medico  
                            WHERE {  
                              ?medico data:adscrito data:"+ips+".  ?medico data:atiende ?paciente.}";
            return excuteQuery(query);
        }
        public DataTable Medicamento(string medicamento)
        {
            string query = @"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                             PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                             PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                             PREFIX data: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#> 
                             SELECT ?enfermedad ?paciente ?pesopaciente ?numdocumento ?nomsintoma 
                             WHERE {  

                              ?enfermedad data:controladopor data:" + medicamento+". ?enfermedad data:afecta ?paciente. ?paciente data:pesopaciente ?pesopaciente.  ?paciente data:numdocumento ?numdocumento.    ?paciente data:nomsintoma ?nomsintoma }";
            return excuteQuery(query);
        }


        public DataTable consultarDatosGenerales(string value)

        {
           
            string query = @"PREFIX owl: <http://www.w3.org/2002/07/owl#>
                             PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                             PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
                             PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                             PREFIX table: <http://www.semanticweb.org/mavig/ontologies/2021/2/salud#>
                             select ?s ?o
                             where {?s ?table ?o.Filter regex(?o,'" + value + "','i')}";
            return excuteQuery(query);
        }
       
       
        public DataTable excuteQuery(string query)
        {
            try
            {
                SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri(baseURL));
                SparqlResultSet srs = endpoint.QueryWithResultSet(query);

                DataTable dataTable = new DataTable();
                var columns = srs.Variables;
                ArrayList l = new ArrayList();
                DataRow dr;
                dr = dataTable.NewRow();
                foreach (string s in columns)
                {
                    dataTable.Columns.Add(new DataColumn(s, typeof(string)));
                    l.Add(s);
                    dr[s] = s;
                }
                dataTable.Rows.Add(dr);

                foreach (var item in srs.Results)
                {
                    

                     dr = dataTable.NewRow();

                    foreach (var result in item)
                    {
                        dr[result.Key] = result.Value;
                    }
                    dataTable.Rows.Add(dr);

                }

                return dataTable;
            }
            catch (Exception ex)
            {
                
                return null;
            }
            
        }
    }
}
    
