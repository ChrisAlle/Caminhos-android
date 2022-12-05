package com.example.apcaminhosmarte;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.renderscript.ScriptGroup;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

public class MainActivity extends AppCompatActivity {

    Cidade[] cidades;
    CaminhosEntreCidades[] caminhos;
    int[][] matrizDeAdjacencias;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        try
        {
            JSONObject cd = new JSONObject(loadCidades());
            JSONArray cds = cd.getJSONArray("");

            for(int i = 0; i < cds.length(); i++)
            {
                JSONObject obj = cds.getJSONObject(i);
                String nome = obj.getString("nomeCidade");
                int coordenadaX = obj.getInt("coordenadaX");
                int coordenadaY = obj.getInt("coordenadaY");

                cidades[i].setNome(nome);
                cidades[i].setX(coordenadaX);
                cidades[i].setY(coordenadaY);
            }
                

        }catch (JSONException e){
        }

        try
        {
            JSONObject cm = new JSONObject(loadDistanciaEntreCidades());
            JSONArray cms = cm.getJSONArray("");

            for(int i = 0; i < cms.length(); i++)
            {
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
        }catch (JSONException e)
        {

        }

        for(CaminhosEntreCidades caminho : caminhos)
        {
            int origem = Arrays.asList(cidades).indexOf(new Cidade(caminho.getOrigem()));
            int destino = Arrays.asList(cidades).indexOf(new Cidade(caminho.getDestino()));

            matrizDeAdjacencias[origem][destino] = caminho.getDistancia();
        }

    }

    public ArrayList<Cidade> caminhoRecursivo(Cidade anterior, Cidade destino)
    {
        ArrayList<Cidade> caminho = null;
        Cidade atual = anterior;
        if(atual == anterior)
            return caminho;
        else
        {

        }


        return caminho;
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