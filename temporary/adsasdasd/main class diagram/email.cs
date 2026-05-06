
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class email : has a user and client {

    public email() {
    }

    public GUID id;

    public Email sender;

    public Email recipient;

    public Email? cc;

    public Email? bcc;

    public string subject;

    public string content;

    public EmailStatus status;

    public datetime? sentAt;

    public bool isHTML;

}