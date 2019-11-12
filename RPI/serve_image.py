from waitress import serve
from flask import Flask, send_file, request

app = Flask(__name__)

@app.route('/getImage')
def SendImage():
    return send_file('Picture.jpg', mimetype='image/jpg')

serve (app,host='0.0.0.0',port=5000)