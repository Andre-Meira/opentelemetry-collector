FROM docker.elastic.co/apm/apm-server:8.15.3
COPY ./elasticsearch/apm-server.yml /usr/share/apm-server/apm-server.yml
USER root
RUN chown apm-server /usr/share/apm-server/apm-server.yml
USER apm-server