# link: http://localhost:5000

from flask import Flask
from flask import request
from flask import render_template
from flask import abort, redirect, url_for, make_response
from flask import send_from_directory
from models import errorModel

app = Flask(__name__)


# Pages
@app.route('/')
def index():
    print('index')
    return render_template('index.html')


@app.route('/redirect')
def redirect_to_home():
    print('dzialam')
    return redirect(url_for('index'))


@app.route('/aboutme')
def aboutme():
    return render_template('aboutme.html')


@app.route('/gallery')
def gallery():
    return render_template('gallery.html')


@app.route('/contact')
def contact():
    return render_template('contact.html')


# ERRORS
@app.route('/error_denied')
def error_denied():
    abort(401)


@app.route('/error_internal')
def error_internal():
    error = errorModel.Error("ERROR 505", "Internal server error")
    return render_template('error.html', data=error)


@app.route('/error_not_found')
def error_not_found():
    error = errorModel.Error("ERROR", "I wasn't prepared for you to do it. Let me know what happened")
    return render_template('error.html', data=error)


@app.errorhandler(404)
def not_found_error(error):
    error = errorModel.Error("ERROR 404", "Not found")
    return render_template('error.html', data=error)


if __name__ == '__main__':
    app.run(host='0.0.0.0')