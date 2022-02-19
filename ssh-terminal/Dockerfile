# ubuntuをベースイメージに設定
FROM ubuntu:18.04

# 作成したユーザの情報
LABEL maintainter="yamada"

# sshサーバをインストール
RUN apt-get update && apt-get install -y openssh-server

RUN apt-get clean

RUN mkdir /var/run/sshd

# rootのパスワードをrootpasswdに設定
RUN echo 'root:password' | chpasswd

# sshのrootでのアクセスを許可
# ただし、パスワードでのアクセスは無効
RUN sed -i 's/#PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN sed -i 's/#PasswordAuthentication/PasswordAuthentication/' /etc/ssh/sshd_config

# sshのポートを22 => 20022に変更します
RUN sed -i 's/#Port 22/Port 20022/' /etc/ssh/sshd_config

# ホスト側にある公開鍵をイメージ側に登録します
# COPY ./config_files/id_rsa.pub /root/.ssh/authorized_keys

EXPOSE 20022
CMD ["/usr/sbin/sshd", "-D"]