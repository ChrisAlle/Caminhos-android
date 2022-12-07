package com.example.apcaminhosmarte;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.renderscript.ScriptGroup;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Stack;


public class MainActivity extends AppCompatActivity {

    Cidade[] cidades;
    String[] nomesCidades;
    CaminhosEntreCidades[] caminhos;
    int[][] matrizDeAdjacencias;
    ValoresDoCaminho[][] valores;
    Spinner dropOrigem;
    Spinner dropDestino;
    Button btnBuscar;
    TextView txtCaminho;
    RadioButton rbRecursao;
    RadioButton rbDijkstra;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
         dropOrigem = (Spinner) findViewById(R.id.dropOrigem);
         dropDestino = (Spinner) findViewById(R.id.dropDestino);
         btnBuscar = (Button) findViewById(R.id.btnBuscar);
         txtCaminho = (TextView) findViewById(R.id.txtCaminho);
         rbRecursao = (RadioButton) findViewById(R.id.rbRecursao);
         rbDijkstra = (RadioButton) findViewById(R.id.rbDijkstra);
         try {
            JSONObject cd = new JSONObject(loadCidades());
            JSONArray cds = cd.getJSONArray("");

            for (int i = 0; i < cds.length(); i++) {
                JSONObject obj = cds.getJSONObject(i);
                String nome = obj.getString("nomeCidade");
                int coordenadaX = obj.getInt("coordenadaX");
                int coordenadaY = obj.getInt("coordenadaY");

                cidades[i].setNome(nome);
                cidades[i].setX(coordenadaX);
                cidades[i].setY(coordenadaY);
                nomesCidades[i] = nome;
            }


        } catch (JSONException e) {
        }

         ArrayAdapter ad = new ArrayAdapter(this, android.R.layout.simple_spinner_dropdown_item, nomesCidades);
         ad.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
         dropOrigem.setAdapter(ad);
         dropDestino.setAdapter(ad);

        try {
            JSONObject cm = new JSONObject(loadDistanciaEntreCidades());
            JSONArray cms = cm.getJSONArray("");

            for (int i = 0; i < cms.length(); i++) {
                JSONObject obj = cms.getJSONObject(i);
                String cidadeDeOrigem = obj.getString("cidadeDeOrigem");
                String cidadeDeDestino = obj.getString("cidadeDeDestino");
                int distancia = obj.getInt("distanciaCaminho");
                int tempo = obj.getInt("tempoCaminho");
                int custo = obj.getInt("custoCaminho");

                caminhos[i].setOrigem(cidadeDeOrigem);
                caminhos[i].setDestino(cidadeDeDestino);
                caminhos[i].setDistancia(distancia);
                caminhos[i].setTempo(tempo);
                caminhos[i].setCusto(custo);
            }
        } catch (JSONException e) {

        }

        for (CaminhosEntreCidades caminho : caminhos) {
            int origem = Arrays.asList(cidades).indexOf(new Cidade(caminho.getOrigem()));
            int destino = Arrays.asList(cidades).indexOf(new Cidade(caminho.getDestino()));

            matrizDeAdjacencias[origem][destino] = caminho.getDistancia();
            valores[origem][destino] = new ValoresDoCaminho(origem, destino, caminho.getDistancia(), caminho.getTempo(), caminho.getCusto());
        }



    }

    public void onClickBtnBuscar(View v) {
        if (dropOrigem.getSelectedItem() == null)
            Toast.makeText(getApplicationContext(),
                            "aaa",
                            Toast.LENGTH_LONG)
                    .show();
        if (dropDestino.getSelectedItem() == null)
            Toast.makeText(getApplicationContext(),
                            "bbb",
                            Toast.LENGTH_LONG)
                    .show();
        if (rbRecursao.isSelected()) {
            int origem = Arrays.asList(nomesCidades).indexOf(dropOrigem.getSelectedItem().toString());
            int destino = Arrays.asList(nomesCidades).indexOf(dropDestino.getSelectedItem().toString());
            setCaminhosRec(origem, destino);
        } else if (rbDijkstra.isSelected())
        {

        }
        else
            Toast.makeText(getApplicationContext(),
                            "ccc",
                            Toast.LENGTH_LONG)
                    .show();



    }

    public void setCaminhosRec(int origem, int destino) {
        int atual = origem;
        int prox = 0;
        Stack<Movimento> pilha = new Stack<Movimento>();
        Boolean[] visitadas = new Boolean[cidades.length];
        for (int i = 0; i < cidades.length; i++) {
            visitadas[i] = false;
        }
        visitadas[origem] = true;

        caminhosRec(origem, destino, atual, prox, visitadas, pilha);

    }

    public void caminhosRec(int origem, int destino, int atual, int prox, Boolean[] visitadas, Stack<Movimento> movimentos) {
        if (prox < visitadas.length) {
            if (prox == destino && matrizDeAdjacencias[atual][prox] != 0) {
                ValoresDoCaminho valor = valores[atual][prox];
                movimentos.push(new
                        Movimento(atual, prox, valor));
                prox++;

            } else if (matrizDeAdjacencias[atual][prox] == 0 || visitadas[prox]) {
                prox++;
                caminhosRec(origem, destino, atual, prox, visitadas, movimentos);
            } else {
                visitadas[atual] = true;
                ValoresDoCaminho valor = valores[atual][prox];
                movimentos.push(new Movimento(atual, prox, valor));
                atual = prox;
                prox = 0;
                caminhosRec(origem, destino, atual, prox, visitadas, movimentos);
            }
        } else if (!movimentos.empty())
        {
            Movimento ultimoMovimento = movimentos.pop();
            atual = ultimoMovimento.getOrigem();
            prox = ultimoMovimento.getDestino() + 1;
            caminhosRec(origem, destino, atual, prox, visitadas, movimentos);
        }
    }



    public String loadCidades()
    {
        String json = null;

            try {
                InputStream is = getAssets().open("cidades.json");
                int size = is.available();
                byte[] buffer = new byte[size];
                is.read(buffer);
                is.close();
                json = new String(buffer,"UTF-8");
            } catch (IOException e) {
                e.printStackTrace();
                return null;
            }
        return json;
    }


    public String loadDistanciaEntreCidades() {
        String json = null;
        try {
            InputStream is = getAssets().open("caminhosEntreCidades.json");
            int size = is.available();
            byte[] buffer = new byte[size];
            is.read(buffer);
            is.close();
            json = new String(buffer, "UTF-8");
        } catch (IOException ex) {
            ex.printStackTrace();
            return null;
        }
        return json;
    }
}