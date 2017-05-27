<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <html>
      <body>
        <xsl:for-each select="Channel/Videos/Video" >
          <div style="text-align:center; border: 1px solid black; border-radius:10px;padding:10px;margin:5px;">
            <p style="font-size:20px;">
              <xsl:value-of select="Title"></xsl:value-of>
            </p>
            <iframe style="width:560px; height:315px;">
              <xsl:attribute name="src">
                https://www.youtube.com/embed/<xsl:value-of select="VideoId" />
              </xsl:attribute>
              <p>Your browser does not support iframes.</p>
            </iframe>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>